using System;
using UnityEngine;
using UnityEngine.Purchasing;

public class PurchaseManager : MonoBehaviour, IStoreListener
{
    private static IStoreController m_StoreController;
    private static IExtensionProvider m_StoreExtensionProvider;
    private int currentProductIndex;

    public string[] NC_PRODUCTS;

    public string[] C_PRODUCTS;

    public static event OnSuccessConsumable OnPurchaseConsumable;

    public static event OnSuccessNonConsumable OnPurchaseNonConsumable;

    public static event OnFailedPurchase PurchaseFailed;

    private void Awake()
    {
        InitializePurchasing();
    }

    public static bool CheckBuyState(string id)
    {
        Product product = m_StoreController.products.WithID(id);
        if (product.hasReceipt) { return true; }
        else { return false; }
    }

    public void InitializePurchasing()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        foreach (string s in C_PRODUCTS) builder.AddProduct(s, ProductType.Consumable);
        foreach (string s in NC_PRODUCTS) builder.AddProduct(s, ProductType.NonConsumable);
        UnityPurchasing.Initialize(this, builder);
    }

    private bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }

    public void BuyConsumable(int index)
    {
        currentProductIndex = index;
        BuyProductID(C_PRODUCTS[index]);
    }

    public void BuyNonConsumable(int index)
    {
        currentProductIndex = index;
        BuyProductID(NC_PRODUCTS[index]);
    }

    void BuyProductID(string productId)
    {
        if (IsInitialized())
        {
            Product product = m_StoreController.products.WithID(productId);

            if (product != null && product.availableToPurchase)
                m_StoreController.InitiatePurchase(product);
            else
                OnPurchaseFailed(product, PurchaseFailureReason.ProductUnavailable);
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (C_PRODUCTS.Length > 0 && string.Equals(args.purchasedProduct.definition.id, C_PRODUCTS[currentProductIndex], StringComparison.Ordinal))
            OnSuccessC(args);
        else if (NC_PRODUCTS.Length > 0 && string.Equals(args.purchasedProduct.definition.id, NC_PRODUCTS[currentProductIndex], StringComparison.Ordinal))
            OnSuccessNC(args);
        return PurchaseProcessingResult.Complete;
    }

    public delegate void OnSuccessConsumable(PurchaseEventArgs args);

    protected virtual void OnSuccessC(PurchaseEventArgs args)
    {
        if (OnPurchaseConsumable != null)
            OnPurchaseConsumable(args);
        switch (C_PRODUCTS[currentProductIndex])
        {
            case "one":
                PlayerPrefs.SetInt("MoneyPlay", PlayerPrefs.GetInt("MoneyPlay") + 1000);
                break;

            case "two":
                PlayerPrefs.SetInt("MoneyPlay", PlayerPrefs.GetInt("MoneyPlay") + 3000);
                break;

            case "three":
                PlayerPrefs.SetInt("MoneyPlay", PlayerPrefs.GetInt("MoneyPlay") + 5000);
                break;

            case "four":
                PlayerPrefs.SetInt("MoneyPlay", PlayerPrefs.GetInt("MoneyPlay") + 10000);
                break;

            case "five":
                PlayerPrefs.SetInt("MoneyPlay", PlayerPrefs.GetInt("MoneyPlay") + 15000);
                break;

            case "six":
                PlayerPrefs.SetInt("MoneyPlay", PlayerPrefs.GetInt("MoneyPlay") + 20000);
                break;
        }
        GameObject.Find("Ads").GetComponent<Buttons>().Purcahase();
    }

    public delegate void OnSuccessNonConsumable(PurchaseEventArgs args);

    protected virtual void OnSuccessNC(PurchaseEventArgs args)
    {
        if (OnPurchaseNonConsumable != null)
            OnPurchaseNonConsumable(args);
        if (NC_PRODUCTS[currentProductIndex] == "ads")
        {
            PlayerPrefs.SetInt("Ads", 1);
            GameObject.Find("Ads").GetComponent<Buttons>().Ads();
        }
    }

    public delegate void OnFailedPurchase(Product product, PurchaseFailureReason failureReason);

    protected virtual void OnFailedP(Product product, PurchaseFailureReason failureReason)
    {
        PurchaseFailed(product, failureReason);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        OnFailedP(product, failureReason);
    }
}